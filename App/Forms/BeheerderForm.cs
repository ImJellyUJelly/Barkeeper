using App.Models;
using App.Services;
using System.Linq;

namespace App.Forms;

public partial class BeheerderForm : Form
{
    private int _initialLoad = 0;

    private ISessionService SessionService { get; }
    private Session? CurrentSession { get; set; }

    public BeheerderForm(ISessionService sessionService)
    {
        InitializeComponent();
        SessionService = sessionService;
        CurrentSession = SessionService.GetCurrentSession();
        cbEvent.Checked = CurrentSession is not null;
        LoadSessions();
    }

    private void LoadSessions()
    {
        lvSessions.Items.Clear();
        var sessions = SessionService.GetSessions(DateTime.Now.Year).OrderByDescending(session => session.Id).ToList();
        foreach (var session in sessions)
        {
            var item = new ListViewItem
            {
                Tag = session,
                Text = session.Id.ToString()
            };
            item.SubItems.Add(session.GetStartDate());
            item.SubItems.Add(session.GetEndDate());
            lvSessions.Items.Add(item);
        }
    }

    private void cbEvent_Click(object sender, EventArgs e)
    {
        if (CurrentSession is null)
        {
            SessionService.CreateSession();
            CurrentSession = SessionService.GetCurrentSession();
        }
        else
        {
            SessionService.EndSession(CurrentSession);
            CurrentSession = null;
        }

        LoadSessions();
    }
}