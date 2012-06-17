using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio_Integra;

namespace Obli_IS2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbTipos.SelectedItem = 1;
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string Id = txtIdentificador.Text;
            string nombre = txtNombre.Text;
            string desc = txtDesc.Text;
            int precio = (int)txtPrecio.Value;
            int dto = (int)txtDtos.Value;
            int impuesto = (int)txtImpuestos.Value;
            string tipo;
            if (cbTipos.SelectedItem == null)
            {
                tipo = "";
            }
            else
            {
                tipo = cbTipos.SelectedItem.ToString();
            }
                string color;
            if(cbColor.SelectedItem == null)
            {
                color = "";
            }
            else
            {
                color = cbColor.SelectedItem.ToString() ;
            }
            
                decimal tam = txtTamaño.Value;
                int peso = (int)txtPeso.Value;
                string descEmpaque = txtDescEmpaque.Text;

                bool ok = true;
                if (Sistema.getInstancia().existeId(Id))
                {
                    ok = false;
                    label12.Text = "Id existente";
                    label12.Visible = true;
                }
                if (Id.Length == 4)
                {
                    try
                    {
                        int check = Int32.Parse(Id);
                        //todo ok
                    }
                    catch (Exception ex)
                    {
                        label12.Visible = true;
                        label12.Text = "Solo digitos";
                        ok = false;
                    }
                }
                else
                {
                    label12.Visible = true;
                        label12.Text = "4 digitos";
                    ok = false;
                }
                nombre.TrimEnd();
                nombre.TrimStart();
                if (nombre.Length <= 10 && !string.IsNullOrEmpty(nombre))
                {
                    //todo ok
                }
                else
                {
                    label13.Visible = true;
                    label13.Text = "hasta 10 caracteres";
                    ok = false;
                }

                if (desc.Length > 250)
                {
                    label22.Visible = true;
                    label22.Text = "hasta 250 caracteres";
                    ok = false;
                }

                if (precio < 0 || precio > 9999)
                {
                    label19.Visible = true;
                    label19.Text = "valor entre 0 y 9999";
                    ok = false;
                }

                if (dto < 0 || dto > 100)
                {
                    label20.Visible = true;
                    label20.Text = "valor entre 0 y 100";
                    ok = false;
                }

                if (impuesto < 0 || impuesto > 999)
                {
                    label21.Visible = true;
                    label21.Text = "valor entre 0 y 999";
                    ok = false;
                }
                if (tipo.Equals("Producto"))
                {
                    if (peso < 0 || peso > 10000)
                    {
                        label16.Visible = true;
                    label16.Text = "valor entre 0 y 10000";
                        ok = false;
                    }
                    if (!color.Equals("ROJO") && !color.Equals("VERDE") && !color.Equals("NEGRO") && !color.Equals("BLANCO"))
                    {
                        label17.Visible = true;
                    label17.Text = "Elija un color";
                        ok = false;
                    }
                    if (tam < 0 || tam > 8)
                    {
                        label18.Visible = true;
                    label18.Text = "valor entre 0 y 8";
                        ok = false;
                    }
                    if (ok)
                    {
                        label12.Visible = false;
                        label13.Visible = false;
                        label14.Visible = false;
                        label15.Visible = false;
                        label16.Visible = false;
                        label17.Visible = false;
                        label18.Visible = false;
                        label19.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false;
                        label22.Visible = false;
                        DialogResult resultado = MessageBox.Show("Usted quiere registrar el siguiente " + tipo + Environment.NewLine +
                                                           "ID: " + Id + " Nombre: " + nombre + Environment.NewLine +
                                                           "Desc: " + desc + Environment.NewLine + 
                                                           "Precio : US$" + precio+Environment.NewLine + 
                                                           "Impuestos: "+impuesto+"%"+Environment.NewLine + 
                                                           "Descuento de: "+dto+"%"+Environment.NewLine + 
                                                           "Con un peso de: "+peso +"Kg" +Environment.NewLine + 
                                                           "Tamaño de "+tam+ " metros cubicos" + Environment.NewLine +
                                                           "Color :"+color +Environment.NewLine +
                                                           "Y un empaque: "+descEmpaque, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(resultado == DialogResult.Yes)
                            Sistema.getInstancia().AltaProducto(Id, nombre, desc, precio, dto, impuesto, descEmpaque, peso, color, tam);
                    }
                }
                else
                {
                    if(tipo.Equals("Servicio"))
                    {
                        if (ok)
                        {
                                                    label12.Visible = false;
                        label13.Visible = false;
                        label14.Visible = false;
                        label15.Visible = false;
                        label16.Visible = false;
                        label17.Visible = false;
                        label18.Visible = false;
                        label19.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false;
                        label22.Visible = false;
                        DialogResult resultado = MessageBox.Show("Usted quiere registrar el siguiente " + tipo + Environment.NewLine +
                                                       "ID: " + Id + " Nombre: " + nombre + Environment.NewLine +
                                                       "Desc: " + desc + Environment.NewLine +
                                                       "Precio : US$" + precio + Environment.NewLine +
                                                       "Impuestos: " + impuesto + "%" + Environment.NewLine +
                                                       "Descuento de: " + dto + "%", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                            Sistema.getInstancia().AltaServicio(Id, nombre, desc, precio, dto, impuesto);
                        }
                    }
                    else
                    {
                        label14.Visible = true;
                        label14.Text = "Seleccione tipo";
                        ok = false;
                    }
                    
                }
                
            }
          
        

        private void cbTipos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTipos.SelectedItem.ToString().Equals("Servicio"))
            {
                txtDescEmpaque.Enabled = false;
                txtPeso.Enabled = false;
                txtTamaño.Enabled = false;
                cbColor.Enabled = false;

            }
            else 
            {
                txtDescEmpaque.Enabled = true;
                txtPeso.Enabled = true;
                txtTamaño.Enabled = true;
                cbColor.Enabled = true;
            
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
