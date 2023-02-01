using EazyQuiz.Models;
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

    public Registration(IFormFactory formFactory, ApiProvider apiProvider)
    {
        _formFactory = formFactory;
        _apiProvider = apiProvider;
        InitializeComponent();
    }

    public void Open()
    {
        if (!Application.OpenForms.OfType<Registration>().Any())
        {
            Show();
        }
    }

    private void RegisterButtonClick(object sender, EventArgs e)
    {
        var userRegister = new UserRegister()
        {
            Email = EmailInput.Text,
            Password = PasswordInput.Text,
            UserName = UsernameInput.Text,
            Age = (int)AgeInput.Value,
            Gender = GenderInput.SelectedIndex + 1,
            Country = GenderInput.SelectedText
        };
        _apiProvider.Registrate(userRegister);
        MessageBox.Show("Регистрация прошла успешно");
        Close();
    }

    private void EnterButtonClick(object sender, EventArgs e)
    {
        Close();
        _formFactory.Create<LogIn>().Open();
    }
}
