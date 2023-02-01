using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EazyQuiz.Desktop.Admin;
public partial class Registration : Form
{
    private readonly IFormFactory _formFactory;
    private readonly ApiProvider _apiProvider;
    private readonly UserToken _userToken;

    public Registration(IFormFactory formFactory, ApiProvider apiProvider, UserToken userToken)
    {
        _formFactory = formFactory;
        _apiProvider = apiProvider;
        _userToken = userToken;
        InitializeComponent();
    }

    private void RegisterButtonClick(object sender, EventArgs e)
    {

    }
}
