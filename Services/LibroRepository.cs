using WebApiLibreria.Models;

namespace WebApiLibreria.Services
{
    public class LibroRepository : ILibro
    {
        private LibreriasC conexion = new LibreriasC();

        public void add(TbLibro libro)
        {
            conexion.TbLibros.Add(libro);
            conexion.SaveChanges();
        }

        public void delete(int IdLibro)
        {
            var objEncontrado = (from tLib in conexion.TbLibros
                                 where tLib.IdLibro == IdLibro
                                 select tLib).Single();
            conexion.Remove(objEncontrado);
            conexion.SaveChanges();
        }

        public TbLibro edit(int id)
        {
            var ObjEncontrado = (from tbLib in conexion.TbLibros
                                 where tbLib.IdLibro == id
                                 select tbLib).Single();
            return ObjEncontrado;
        }

        public void editDetails(TbLibro obj)
        {
            var objEncontrado = (from tbLib in conexion.TbLibros
                                 where tbLib.IdLibro == obj.IdLibro
                                 select tbLib).FirstOrDefault();
            objEncontrado.Titulo = obj.Titulo;
            objEncontrado.Genero = obj.Genero;
            objEncontrado.Autor = obj.Autor;
            objEncontrado.Año = obj.Año;
            objEncontrado.Stock = obj.Stock;
            objEncontrado.Link = obj.Link;
            conexion.SaveChanges();
        }

        public IEnumerable<TbLibro> GetAllLibro()
        {
            return conexion.TbLibros;
        }

        public TbLibro GetLibro(int IdLibro)
        {
            var ObjProducto = (from tlib in conexion.TbLibros
                               where tlib.IdLibro == IdLibro
                               select tlib).FirstOrDefault();
            return ObjProducto;
        }
    }
}
