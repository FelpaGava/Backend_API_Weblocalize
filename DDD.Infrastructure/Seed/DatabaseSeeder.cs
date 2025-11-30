using DDD.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(WebLocalizeDbContext context)
        {
            if (!context.Estados.Any())
            {
                var estados = new[]
                {
                    new Estado { UFNOME = "São Paulo", UFSIGLA = "SP", UFSITUACAO = 'A'},
                    new Estado { UFNOME = "Rio de Janeiro", UFSIGLA = "RJ", UFSITUACAO = 'A'},
                    new Estado { UFNOME = "Minas Gerais", UFSIGLA = "MG", UFSITUACAO = 'A'},
                    new Estado { UFNOME = "Bahia", UFSIGLA = "BA", UFSITUACAO = 'A' },
                    new Estado { UFNOME = "Paraná", UFSIGLA = "PR", UFSITUACAO = 'A'}
                };
                context.Estados.AddRange(estados);
                context.SaveChanges();
            }

            if (!context.Cidades.Any())
            {
                var estados = context.Estados.ToList();
                var cidades = new[]
                {
                    new Cidade { CIDNOME = "São Paulo", CIDUF = estados[0].UFID, CIDSITUACAO = 'A'},
                    new Cidade { CIDNOME = "Rio de Janeiro", CIDUF = estados[1].UFID, CIDSITUACAO = 'A'},
                    new Cidade { CIDNOME = "Belo Horizonte", CIDUF = estados[2].UFID, CIDSITUACAO = 'A'},
                    new Cidade { CIDNOME = "Salvador", CIDUF = estados[3].UFID, CIDSITUACAO = 'A'},
                    new Cidade { CIDNOME = "Curitiba", CIDUF = estados[4].UFID, CIDSITUACAO = 'A' }
                };
                context.Cidades.AddRange(cidades);
                context.SaveChanges();
            }

            if (!context.Locais.Any())
            {
                var cidades = context.Cidades.ToList();
                var estados = context.Estados.ToList();
                var locais = new[]
                {
                    new Local { LOCNOME = "Parque Ibirapuera", LOCCID = cidades[0].CIDID, LOCUF = estados[0].UFID, LOCSITUACAO = 'A'},
                    new Local { LOCNOME = "Cristo Redentor", LOCCID = cidades[1].CIDID, LOCUF = estados[1].UFID, LOCSITUACAO = 'A'},
                    new Local { LOCNOME = "Praça da Liberdade", LOCCID = cidades[2].CIDID, LOCUF= estados[2].UFID, LOCSITUACAO = 'A'},
                    new Local { LOCNOME = "Pelourinho", LOCCID = cidades[3].CIDID, LOCUF = estados[3].UFID, LOCSITUACAO = 'A'},
                    new Local { LOCNOME = "Jardim Botânico", LOCCID = cidades[4].CIDID, LOCUF = estados[4].UFID, LOCSITUACAO = 'A'}
                };
                context.Locais.AddRange(locais);
                context.SaveChanges();
            }
        }
    }
}
