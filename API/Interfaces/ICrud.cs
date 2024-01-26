using Microsoft.EntityFrameworkCore;

namespace API_2.Interfaces
{
    public interface ICrud<T>
    {
        public List<T> consultar();
        public bool inserir(T t);
        public void deletar(int id);
        public bool alterar(T t);
    }
}
