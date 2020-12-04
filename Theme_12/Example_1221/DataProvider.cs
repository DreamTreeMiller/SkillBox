using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1221
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    class DataProvider
    {
        /// <summary>
        /// База данных сотрудников
        /// </summary>
        private Worker[] Workers;

        /// <summary>
        /// Возвращает экземпляр Worker, или null если такого экземпляра нет
        /// </summary>
        /// <param name="index">Позиция в базе данных</param>
        /// <returns>Worker</returns>
        public Worker this[int index]
        {
            get { return this.Workers[index]; }
        }

        /// <summary>
        /// Возвращает экземпляр Worker или null если такого экземпляра нет
        /// </summary>
        /// <param name="Name">Предположительное имя в базе данных</param>
        /// <returns>Worker</returns>
        public Worker this[string Name]
        {
            get
            {
                Worker t = null;
                foreach (var e in this.Workers)
                {
                    if (e.FirstName == Name) { t = e; break; }
                }
                return t;
            }
        }

        /// <summary>
        /// Возвращает экземпляр Worker или null если такого экземпляра нет
        /// </summary>
        /// <param name="Name">Предположительное имя в базе данных</param>
        /// <param name="Position">Предположительная должность в базе данных</param>
        /// <returns>Worker</returns>
        public Worker this[string Name, string Position]
        {
            get
            {
                Worker t = null;
                foreach (var e in this.Workers)
                {
                    if (e.FirstName == Name && e.Position == Position) { t = e; break; }
                }
                return t;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Args">Список сотрудников</param>
        public DataProvider(params Worker[] Args)
        {
            Workers = Args;
        }
    }
}
