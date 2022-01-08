using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        // Lazy loading = sadece ihtiyaç olduğunda yüklesin
        // ilk bu object mapperin içindeki ben istediğim zaman yüklensin,
        // ben çağırmazsam memoryde bulunmasın

        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();

            });

            return config.CreateMapper();

        });

        // bu şekilde sadece get yapısını kodlarım. sadece datayı alıcam
        // ObjectMapper sınıfının Mapper' ini çağırana kadar yukardaki kod yüklenmicek.
        public static IMapper Mapper => lazy.Value;
    }
}
