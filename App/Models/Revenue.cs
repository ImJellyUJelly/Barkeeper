﻿namespace App.Models;

public class Revenue
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public PayMethod PayMethod { get; set; }
    public DateTime SaleDate { get; set; }
}