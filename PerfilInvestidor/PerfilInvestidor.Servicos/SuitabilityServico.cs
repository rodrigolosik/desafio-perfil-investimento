using PerfilInvestidor.Modelos.Suitability;
using PerfilInvestidor.Repositorios;
using System.Collections.Generic;

namespace PerfilInvestidor.Servicos
{
    public class SuitabilityServico : ISuitabilityServico
    {
        private readonly SuitabilityRepositorio _repo = new SuitabilityRepositorio();

        public void LimparRelacionamentoUsuarioResposta(int usuarioId)
        {
            _repo.LimparRelacionamentoUsuarioResposta(usuarioId);
        }

        public IEnumerable<UsuarioResposta> ListarRespostasPorUsuario(int usuarioId)
        {
            return _repo.ListarRespostasPorUsuario(usuarioId);
        }

        public void SalvarRelacaoUsuarioResposta(int usuarioId, ICollection<int> respostaIds)
        {
            if (respostaIds.Count > 0)
            {
                _repo.LimparRelacionamentoUsuarioResposta(usuarioId);

                foreach (var resposta in respostaIds)
                {
                    _repo.SalvarRelacaoUsuarioResposta(usuarioId, resposta);
                }
            }
        }

        public Suitability Selecionar()
        {
            return _repo.Selecionar();
        }

        public Suitability SelecionarMock()
        {
            return new Suitability()
            {
                Perguntas = new List<Pergunta>()
                {
                    new Pergunta()
                    {
                        Id = 1,
                        Texto = "Qual faixa de valor correspondente aos seus rendimentos mensais?",
                        Respostas = new List<Resposta>()
                        {
                            new Resposta()
                            {
                                Id = 1,
                                Valor = 1,
                                Texto = "Até R$ 5.000,00"
                            },
                            new Resposta()
                            {
                                Id = 2,
                                Valor = 5,
                                Texto = "De R$ 5.000,00 até  R$ 30.000,00"
                            },
                            new Resposta()
                            {
                                Id = 3,
                                Valor = 8,
                                Texto = "Acima de R$ 30.000,00"
                            }
                        }
                    },
                    new Pergunta()
                    {
                        Id = 2,
                        Texto = "Qual das opções abaixo melhor representa seu conhecimento do mercado financeiro?",
                        Respostas = new List<Resposta>()
                        {
                            new Resposta()
                            {
                                Id = 4,
                                Valor = 0,
                                Texto = "Não concluí o ensino superior e minha experiência profissional não possui relação com o mercado financeiro."
                            },
                            new Resposta()
                            {
                                Id = 5,
                                Valor = 2,
                                Texto = "Concluí o ensino superior, porém minha experiência profissional não possui relação com o mercado financeiro."
                            },
                            new Resposta()
                            {
                                Id = 6,
                                Valor = 6,
                                Texto = "Apesar de não ter concluído o ensino superior, minha experiência profissional aprimorou meus conhecimentos sobre o mercado financeiro."
                            },
                            new Resposta()
                            {
                                Id = 7,
                                Valor = 8,
                                Texto = "Concluí o ensino superior e minha experiência profissional aprimorou meus conhecimentos sobre o mercado financeiro."
                            }
                        }
                    },
                    new Pergunta()
                    {
                        Id = 3,
                        Texto = "Seus investimentos representam que percentual do total do seu patrimônio?",
                        Respostas = new List<Resposta>()
                        {
                            new Resposta()
                            {
                                Id = 8,
                                Valor = 2,
                                Texto = "Até 25%"
                            },
                            new Resposta()
                            {
                                Id = 9,
                                Valor = 6,
                                Texto = "Entre 26% e 50%"
                            },
                            new Resposta()
                            {
                                Id = 10,
                                Valor = 8,
                                Texto = "Mais de 51%"
                            }
                        }
                    },
                    new Pergunta()
                    {
                        Id = 4,
                        Texto = "Em quais produtos financeiros você investiu nos últimos 24 meses?",
                        Respostas = new List<Resposta>()
                        {
                            new Resposta()
                            {
                                Id = 11,
                                Valor = 2,
                                Texto = "Somente Poupança, títulos públicos e outros produtos de Renda Fixa."
                            },
                            new Resposta()
                            {
                                Id = 12,
                                Valor = 6,
                                Texto = "Além dos produtos da alternativa acima, produtos de Renda Variável (fundos de ações, ações e similares)."
                            },
                            new Resposta()
                            {
                                Id = 13,
                                Valor = 8,
                                Texto = "Além dos produtos acima, mercado futuro e outros derivativos."
                            },
                            new Resposta()
                            {
                                Id = 14,
                                Valor = 10,
                                Texto = "Não investi no período."
                            }
                        }
                    },
                    new Pergunta()
                    {
                        Id = 5,
                        Texto = "Qual o volume investido em produtos financeiros nos últimos 24 meses?",
                        Respostas = new List<Resposta>()
                        {
                            new Resposta()
                            {
                                Id = 15,
                                Valor = 2,
                                Texto = "Até R$ 100.000,00"
                            },
                            new Resposta()
                            {
                                Id = 16,
                                Valor = 6,
                                Texto = "Entre R$ 100.000,00 e R$ 500.000,00"
                            },
                            new Resposta()
                            {
                                Id = 17,
                                Valor = 8,
                                Texto = "Acima de R$ 500.000,00"
                            },
                            new Resposta()
                            {

                                Id = 18,
                                Valor = 0,
                                Texto = "Não investi no período"
                            }
                        }
                    }
                }
            };
        }
    }
}
