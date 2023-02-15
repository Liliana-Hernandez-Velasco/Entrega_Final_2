using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Entrega_Final_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola René!");
        }
    }
}
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NombreUsuario { get; set; }
    public string NombreLogin { get; }
    public double Contraseña { get; set; }
    public double ContraseñaLogin { get; }
    public double Mail { get; set; }
}
public class Producto
{
    public long Id { get; set; }
    public string Descripción { get; set; }
    public double Costo { get; set; }
    public double PrecioVenta { get; set; }
    public int Stock { get; set; }
    public long IdUsuario { get; set; }
}
public class ProductoVendido
{
    public long Id { get; set; }
    public long IdProducto { get; set; }
    public int Stock { get; set; }
    public long IdVenta { get; set; }
    public long IdUsuario { get; set; }

}
public class Venta
{
    public long Id { get; set; }
    public string Comentarios { get; set; }
    public long IdUsuario { get; set; }

}
public class ProgramaUsuario
{
    public static List<Usuario> DevolverUsuarios()
    {
        List<Usuario> usuarios = new List<Usuario>();
        var listaUsuarios = new List<Usuario>();
        string connectionString = "Server=HERNANDL3;Database=SistemaGestion;Trusted_Connection=True";
        var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail, FROM Usuario";
        using (SqlConnection connect = new SqlConnection(connectionString))
        {
            using (SqlCommand comando = new SqlCommand(query, connect))
            {
                connect.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(dr["Id"]);
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                            usuario.Contraseña = Convert.ToDouble(dr["Contraseña"]);
                            usuario.Mail = Convert.ToDouble(dr["Mail"]);
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
        }
        return listaUsuarios;
    }
}
public class ProgramaProducto
{
    public static List<Producto> DevolverProductos()
    {
        List<Producto> productos = new List<Producto>();
        var listaProductos = new List<Producto>();
        string connectionString = "Server=HERNANDL3;Database=SistemaGestion;Trusted_Connection=True";
        var query = "SELECT Id, Descripción, Costo, PrecioVenta, Stock, IdUsuario, FROM Producto";
        using (SqlConnection connect = new SqlConnection(connectionString))
        {
            using (SqlCommand comando = new SqlCommand(query, connect))
            {
                connect.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            producto.Id = Convert.ToInt32(dr["Id"]);
                            producto.Descripción = dr["Descripción"].ToString();
                            producto.Costo = Convert.ToInt32(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                            producto.Stock = Convert.ToInt32(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                            listaProductos.Add(producto);
                        }
                    }
                }
            }
        }
        return listaProductos;
    }
}
public class ProgramaProductoVendido
{
    public static List<ProductoVendido> DevolverProductoVendido()
    {
        List<ProductoVendido> productosvendidos = new List<ProductoVendido>();
        var listaProductosVendidos = new List<ProductoVendido>();
        string connectionString = "Server=HERNANDL3;Database=SistemaGestion;Trusted_Connection=True";
        var query = "SELECT Id, IdProducto, Stock, IdVenta, IdUsuario FROM ProductoVendido";
        using (SqlConnection connect = new SqlConnection(connectionString))
        {
            using (SqlCommand comando = new SqlCommand(query, connect))
            {
                connect.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var productovendido = new ProductoVendido();
                            productovendido.Id = Convert.ToInt32(dr["Id"]);
                            productovendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            productovendido.Stock = Convert.ToInt32(dr["Stock"]);
                            productovendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                            productovendido.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                            listaProductosVendidos.Add(productovendido);
                        }
                    }
                }
            }
        }
        return listaProductosVendidos;
    }
}
public class ProgramaVentas
{
    public static List<Venta> DevolverVentas()
    {
        List<Venta> Ventas = new List<Venta>();
        var listaVentas = new List<Venta>();
        string connectionString = "Server=HERNANDL3;Database=SistemaGestion;Trusted_Connection=True";
        var query = "SELECT Id, IdProducto, Stock, IdVenta, IdUsuario FROM Venta";
        using (SqlConnection connect = new SqlConnection(connectionString))
        {
            using (SqlCommand comando = new SqlCommand(query, connect))
            {
                connect.Open();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var venta = new Venta();
                            venta.Id = Convert.ToInt32(dr["Id"]);
                            venta.Comentarios = dr["IdProducto"].ToString();
                            venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                            listaVentas.Add(venta);
                        }
                    }
                }
            }
        }
        return listaVentas;
    }
}