namespace GUI_QuanLyTraiCay
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            Task.Delay(3000).ContinueWith(t =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.Invoke(new Action(() =>
                    {
                        frmLogin login = new frmLogin();
                        login.Show();
                        this.Hide();
                    }));
                }
            });
        }
    }
}
