using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess //DataAccess.Abstract'tı değiştirdik. kesip yapıştırınca aynısı kaldı
{
    //Generic constraint:Generic kısıt, T'yi kısıtladık(T: class, IEntity)
    //class: referans tip
    //IEntity: "T" IEntity olabilir yada IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olabilir.(Normalde interfaceler newlenemez ama bununla IEntity'i new'ledik)
    public interface IEntityRepository<T> where T: class, IEntity, new() //Bir yazılımda bu hareketi bir kez yaparsın.
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);//Expression filtre vermek,vfeltre=null, filtre vermeyebilirsin demek
        T Get(Expression<Func<T, bool>> filter);//Tek bir dataya gitmek için örneğin bankacılık sektöründe bir kişinin detayına gitmek
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        //List<Product> GetAllByCategory(int categoryId);
        //List<T> GetAllByCategory(int CategoryId);  Expression yaptığımız için artık bu koda ihtiyacımız yok
    }
}
