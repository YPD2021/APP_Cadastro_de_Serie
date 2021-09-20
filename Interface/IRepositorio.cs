using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Cadastro_de_Serie.Interface
{
    public interface IRepositorio<T>
    {
        List<T> lista();
        T retornaporId(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void Actualizar(int id, T entidade);
        int proximoId();

    }
}
