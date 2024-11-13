using EstadosCidades.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadosCidades.ViewModels
{
    public partial class MainPage : ContentPage
    {
        private BrasilApiService _brasilApiService;

        public object PickerCidade { get; private set; }
        public object LabelPrevisaoAtual { get; private set; }
        public object ListaPrevisao { get; private set; }
        public object PickerEstado { get; private set; }

        public MainPage(object pickerCidade)
        {
            InitializeComponent();
            _brasilApiService = new BrasilApiService();
            CarregarEstados();
            PickerCidade = pickerCidade;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private async void CarregarEstados()
        {
            var estados = await _brasilApiService.BuscarEstados();
            PickerEstado = estados.Select(e => e.Sigla).ToList();
        }

        private OnEstadoSelecionado(object sender, EventArgs e)
        {
            OnEstadoSelecionado(sender, e, PickerCidade);
        }

        private async void OnEstadoSelecionado(object sender, EventArgs e, object pickerCidade)
        {
            

            if (PickerEstado is not string estadoSelecionado)
            {
                return;
            }
            var cidades = await _brasilApiService.BuscarCidadesPorEstado(estadoSelecionado);
            pickerCidade = cidades.Select(c => c.Nome).ToList();
        }


        private BrasilApiService Get_brasilApiService()
        {
            return _brasilApiService;
        }

        private object GetListaPrevisao()
        {
            return ListaPrevisao;
        }

        private object GetLabelPrevisaoAtual()
        {
            return LabelPrevisaoAtual;
        }

        private async void OnCidadeSelecionada(object sender, EventArgs e, BrasilApiService _brasilApiService, object listaPrevisao, object labelPrevisaoAtual)
        {
            var cidadeSelecionada = (string)PickerCidade;

            if (!string.IsNullOrEmpty(cidadeSelecionada))
            {
                    var previsao = await _brasilApiService.BuscarPrevisaoPorCidade(cidadeSelecionada);

                    if (previsao != null && previsao.ClimaProximosDias.Any())
                    {
                        labelPrevisaoAtual = $"Previsão para {cidadeSelecionada}: {previsao.ClimaProximosDias.First().CondicaoDesc}";
                        listaPrevisao = previsao.ClimaProximosDias.Skip(1);
                    }
                }
            }
        }
    }
