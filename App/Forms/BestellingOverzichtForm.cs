﻿using App.Services;
using App.Models;

namespace App.Forms;

public partial class BestellingOverzichtForm : Form
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _memberService;
    private readonly IMoneyCalculator _moneyCalculator;

    public BestellingOverzichtForm(IOrderService orderService, ICustomerService memberService, IMoneyCalculator moneyCalculator)
    {
        _orderService = orderService;
        _memberService = memberService;
        _moneyCalculator = moneyCalculator;

        InitializeComponent();
        LoadOrders();
    }

    private void LoadOrders()
    {
        btMergeOrders.Enabled = false;
        btSplitOrder.Enabled = false;
        btPay.Enabled = false;

        lvOrders.Items.Clear();
        List<Order> orders = _orderService.GetOrders()
            .OrderBy(order => order.IsPaid)
            .ThenBy(order => order.OrderDate)
            .ToList();

        foreach (Order order in orders)
        {
            var item = new ListViewItem();
            item.Tag = order;
            item.Text = order.Id.ToString();
            item.SubItems.Add(order.Customer.Name);
            item.SubItems.Add(GetTextFromBool(order.IsMember));
            item.SubItems.Add($"{order.OrderDate.ToString("dd/MM/yyyy")} - {order.OrderDate.ToShortTimeString()}");
            item.SubItems.Add(GetTextFromBool(order.IsPaid));
            item.SubItems.Add(GetTextFromBool(order.IsFinished));
            item.SubItems.Add(order.OrderDetails.Count.ToString());
            item.SubItems.Add(order.Comment);
            lvOrders.Items.Add(item);
        }
    }

    private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvOrders.SelectedItems.Count > 0 && lvOrders.SelectedItems.Count < 2)
        {
            btSplitOrder.Enabled = true;
        }
        else
        {
            btSplitOrder.Enabled = false;
        }

        if (lvOrders.SelectedItems.Count > 1)
        {
            btMergeOrders.Enabled = true;
        }
        else
        {
            btMergeOrders.Enabled = false;
        }

        if (lvOrders.SelectedItems.Count == 1)
        {
            btPay.Enabled = true;
        }
        else
        {
            btPay.Enabled = false;
        }
    }

    private void btMergeOrders_Click(object sender, EventArgs e)
    {
        List<Order> orders = new List<Order>();
        foreach (ListViewItem item in lvOrders.SelectedItems)
        {
            orders.Add((Order)item.Tag);
        }

        var form = new BestellingenSamenvoegenForm(_orderService, orders);
        form.ShowDialog();
        LoadOrders();
    }

    private void btSplitOrder_Click(object sender, EventArgs e)
    {
        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        if (order == null) { return; }

        var form = new SplitBestellingForm(_orderService, _memberService, _moneyCalculator, order);
        form.ShowDialog();
        LoadOrders();
    }

    private void lvOrders_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A && e.Control)
        {
            foreach (ListViewItem item in lvOrders.Items)
            {
                item.Selected = true;
            }
        }
    }

    private string GetTextFromBool(bool value)
    {
        if (value)
        {
            return "Ja";
        }
        return "Nee";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Order order = (Order)lvOrders.SelectedItems[0].Tag;
        if (order == null) { return; }

        var form = new AfrekenForm(_orderService, _moneyCalculator, order);
        form.ShowDialog();

        LoadOrders();
    }
}