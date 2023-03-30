using AppCEP.Model;
using AppCEP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCEP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnderecoPorCep : ContentPage
    {
        public EnderecoPorCep()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;
                
                Endereco endereco = await DataService.GetEnderecoByCep(lst_ceps.Text);

                BindingContext= endereco;

                //Console.WriteLine("________________________________________");
                //Console.WriteLine(endereco.descricao_cidade);
                

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                Console.WriteLine(ex.StackTrace);

            }
            finally
            {
                carregando.IsRunning = false;
            }

        }

       
    }
}