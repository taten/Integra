using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dominio_Integra
{
    public class Sistema
    {
        private static Sistema instancia;
        private ModeloContainer BD;

        private Sistema()
        {
            BD = new ModeloContainer();
        }

        public static Sistema getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }

        public void AltaProducto(string Id, string nombre, string desc, int precio, int dto, int impuesto, string descEmpaque, int peso, string color, decimal tam)
        {
            bool ok = true;
            if (existeId(Id))
            {
                ok = false;
            }
            if (Id.Length == 4)
            {
                try
                {
                    int check = Int32.Parse(Id);
                    //todo ok
                }
                catch (Exception e)
                {
                    ok = false;
                }
            }
            else
            {
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
                ok = false;
            }

            if (desc.Length > 250)
            {
                ok = false;
            }

            if (precio < 0 || precio > 9999)
            {
                ok = false;
            }

            if (dto < 0 || dto > 100)
            {
                ok = false;
            }

            if (impuesto < 0 || impuesto > 999)
            {
                ok = false;
            }

            if (peso < 0 || peso > 10000)
            {
                ok = false;
            }
            if (!color.Equals("ROJO") && !color.Equals("VERDE") && !color.Equals("NEGRO") && !color.Equals("BLANCO"))
            {
                ok = false;
            }
            if (tam < 0 || tam > 8)
            {
                ok = false;
            }

            if (ok)
            {
                Producto p = new Producto();
                p.color = color;
                p.descripcion = desc;
                p.descripcion_empaque = descEmpaque;
                p.descuento = dto.ToString();
                p.nombre = nombre;
                p.precio = precio.ToString();
                    p.id = Id;
                p.tamano  =tam.ToString();
                p.peso = peso.ToString();
                p.impuesto = impuesto.ToString();
                BD.ProductoEstablecer.AddObject(p);
                BD.SaveChanges();
            
            }

        }

        public void AltaServicio( string Id, string nombre, string desc, int precio, int dto, int impuesto)
        {
            bool ok = true;
            if (existeId(Id))
            {
                ok = false;
            }
            if (Id.Length == 4)
            {
                try
                {
                    int check = Int32.Parse(Id);
                    //todo ok
                }
                catch (Exception e)
                {
                    ok = false;
                }
            }
            else
            {
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
                ok = false;
            }

            if (desc.Length > 250)
            {
                ok = false;
            }

            if (precio < 0 || precio >9999)
            { 
                ok = false;
            }

            if (dto < 0 ||  dto > 100)
            {
                ok = false;
            }

            if (impuesto < 0 || impuesto > 999)
            {
                ok = false;
            }

            if (ok)
            {

                Servicio s = new Servicio();
                s.id = Id;
                s.nombre = nombre;
                s.precio = precio.ToString();
                s.impuesto = impuesto.ToString();
                s.descuento = dto.ToString();
                s.descripcion = desc;
                BD.ServicioEstablecer.AddObject(s);
                BD.SaveChanges();
  
            }
        }

        public bool existeId(string ID)
        {
            List<Servicio> ls = (from s in BD.ServicioEstablecer where s.id == ID select s).ToList();
            List<Producto> lp = (from s in BD.ProductoEstablecer where s.id == ID select s).ToList();
            if (ls.Count == 0 && lp.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
