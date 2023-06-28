using WebApiLibreria.Models;

namespace WebApiLibreria.Services
{
    public interface ILibro
    {
        IEnumerable<TbLibro> GetAllLibro();
        TbLibro GetLibro(int IdLibro);
        void add(TbLibro libro);
        TbLibro edit(int id);
        void delete(int IdLibro);
        void editDetails(TbLibro obj);
    }
}
