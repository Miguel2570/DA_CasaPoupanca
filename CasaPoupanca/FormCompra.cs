using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.Helpers;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CasaPoupanca
{
    public partial class FormCompra : Form
    {
        private CompraController _controller;
        private ArtigoController _artigoController;

        public FormCompra()
        {
            InitializeComponent();

            _controller = new CompraController();
            _artigoController = new ArtigoController();

            try
            {
                CarregarTiposArtigo();
                CarregarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar compras: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNomeCompra.Clear();
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void CarregarCompras()
        {
            var compras = _controller.GetComprasByUtilizador(Session.UtilizadorId);
            listBoxCompras.DataSource = null;
            listBoxCompras.DataSource = compras;
            listBoxCompras.DisplayMember = "Nome";
            listBoxCompras.ValueMember = "Id";
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nomeCompra = textBoxNomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeCompra))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            try
            {
                var novaCompra = new Compra
                {
                    Nome = nomeCompra,
                    DataCriacao = DateTime.Now,
                    CriadoPorId = Session.UtilizadorId,
                    IsFechada = false
                };

                _controller.AddCompra(novaCompra);
                MessageBox.Show("Compra adicionada com sucesso!");
                CarregarCompras();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar compra: {ex.Message}");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxCompras.SelectedItem == null)
            {
                MessageBox.Show("Nenhuma compra selecionada para edição.");
                return;
            }

            string nomeCompra = textBoxNomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeCompra))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            try
            {
                var compraSelecionada = (Compra)listBoxCompras.SelectedItem;

                var compra = new Compra
                {
                    Id = compraSelecionada.Id,
                    Nome = nomeCompra,
                    AlteradoPorId = Session.UtilizadorId,
                    DataAlteracao = DateTime.Now
                };

                if (_controller.UpdateCompra(compra))
                {
                    MessageBox.Show("Compra editada com sucesso!");
                    CarregarCompras();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Compra não encontrada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar compra: {ex.Message}");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma compra para remover.");
                return;
            }

            try
            {
                var compraSelecionada = (Compra)listBoxCompras.SelectedItem;

                if (compraSelecionada.IsFechada)
                {
                    MessageBox.Show("Não pode remover uma compra já fechada.");
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover esta compra?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (_controller.DeleteCompra(compraSelecionada.Id))
                    {
                        MessageBox.Show("Compra removida com sucesso!");
                        CarregarCompras();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Compra não encontrada.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover compra: {ex.Message}");
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCompras.SelectedItem is Compra compra)
            {
                textBoxNomeCompra.Text = compra.Nome;
                buttonAdicionar.Enabled = false;
                buttonEditar.Enabled = true;
            }
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _artigoController.GetAllTipos();

            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
        }

        private void CarregarArtigosPorTipo(int tipoId)
        {
            var artigos = _artigoController.GetArtigosFiltrados(tipoId);

            comboBoxArtigo.DataSource = artigos;
            comboBoxArtigo.DisplayMember = "Nome";
            comboBoxArtigo.ValueMember = "Id";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedValue == null)
                return;

            if (int.TryParse(comboBoxTipo.SelectedValue.ToString(), out int tipoId))
            {
                CarregarArtigosPorTipo(tipoId);
            }
        }

        private void comboBoxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomeCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
