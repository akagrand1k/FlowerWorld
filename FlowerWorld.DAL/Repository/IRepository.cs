using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.DAL.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Возвращает все записи указанной сущности.
        /// </summ3rq   ary>
        IQueryable<T> Get { get; }

        /// <summary>
        /// Создает новую сущность.
        /// </summary>
        /// <param name="entry">Сущность EF.</param>             
        void Add(T entry);

        /// <summary>
        /// Удаляет указанную сущность из источника данных.
        /// </summary>
        /// <param name="entry">Сущность EF</param>
        void Delete(T entry);

        /// <summary>
        /// Удаляет сущность из источника данных по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        void Delete(int id);

        /// <summary>
        /// Обновляет указанную сущность в источнике данных.
        /// </summary>
        /// <param name="entry">Сущность EF.</param>
        void Update(T entry);

        /// <summary>
        /// Получает сущность по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        T GetById(int id);

        FlowerContext GetContext();
    }
}