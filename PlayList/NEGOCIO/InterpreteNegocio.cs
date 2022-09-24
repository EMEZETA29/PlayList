using Microsoft.AspNetCore.Mvc.Rendering;
using PlayList.DATOS;
using PlayList.DATOS.Entidades;
using PlayList.DATOS.Repositorios;
using PlayList.DTO;

namespace PlayList.NEGOCIO
{
    public class InterpreteNegocio : IInterpreteNegocio
    {
        private readonly IInterpreteRepositorio _interpreteRepositorio;
        private readonly IGeneroRepositorio _generoRepositorio;

        public InterpreteNegocio(IInterpreteRepositorio interpreteRepositorio, IGeneroRepositorio generoRepositorio)
        {
            _interpreteRepositorio = interpreteRepositorio;
            _generoRepositorio = generoRepositorio;
        }
        public List<InterpreteDTO> ObtenerTodos()
        {
            var listaDTO = new List<InterpreteDTO>();
            var listaEntidades = _interpreteRepositorio.ObtenerTodos();
            foreach (var entidades in listaEntidades)
            {
                var nuevoInterpreteDTO = new InterpreteDTO()
                {
                    IDInterprete = entidades.IDInterprete,
                    NombreInterprete = entidades.NombreInterprete,
                    FechaNacimiento = entidades.FechaNacimiento,
                    Genero = entidades.Genero

                };
                listaDTO.Add(nuevoInterpreteDTO);
            }
            return listaDTO;
        }
        public List<InterpreteParaGuardarDTO> ObternerTodosIndex()
        {
            var listaInterpreteDTO = new List<InterpreteParaGuardarDTO>();
            var listaIntrepreteEntidades = _interpreteRepositorio.ObtenerTodos();
            foreach (var entidad in listaIntrepreteEntidades)
            {
                var InterpreteDTO = new InterpreteParaGuardarDTO()
                {
                    NombreInterprete = entidad.NombreInterprete,
                    FechaNacimiento = entidad.FechaNacimiento,
                    Pais = entidad.Pais,
                    ImagenUrl = entidad.ImagenUrl,
                    GeneroID = entidad.GeneroID
                };
                listaInterpreteDTO.Add(InterpreteDTO);
            }
            return listaInterpreteDTO;
        }
        public SelectList ObtenerGenerosLista()
        {
            var generos = _generoRepositorio.ObtenerTodas();
            var listadoGeneros = new SelectList(generos, "IDGenero", "NombreGenero");
            return listadoGeneros;
        }

        public void CrearInterprete(InterpreteParaGuardarDTO interpreteParaGuardarDTO)
        {
            var interprete = new Interpretes
                {
                NombreInterprete = interpreteParaGuardarDTO.NombreInterprete,
                FechaNacimiento = interpreteParaGuardarDTO.FechaNacimiento == null ? null :  Convert.ToDateTime(interpreteParaGuardarDTO.FechaNacimiento),
                Pais = interpreteParaGuardarDTO.Pais,
                ImagenUrl = interpreteParaGuardarDTO.ImagenUrl,
                GeneroID = (int)interpreteParaGuardarDTO.GeneroID
            };
            _interpreteRepositorio.CrearInterprete(interprete);
        }

        public InterpreteParaEditarDTO ObtenerInterpretePorId(int id)
        {
            var interprete = _interpreteRepositorio.ObtenerPorId(id);
            var interpreteDTO = new InterpreteParaEditarDTO
            {
                IDInterprete = interprete.IDInterprete,
                NombreInterprete = interprete.NombreInterprete,
                FechaNacimiento = interprete.FechaNacimiento,
                Pais = interprete.Pais,
                ImagenUrl = interprete.ImagenUrl,
                GeneroID = interprete.GeneroID
            };
            return interpreteDTO;
        }

        public void ActualizarInterprete(InterpreteParaEditarDTO interpreteParaEditarDTO)
        {
            var interprete = new Interpretes
            {
                IDInterprete = interpreteParaEditarDTO.IDInterprete,
                NombreInterprete = interpreteParaEditarDTO.NombreInterprete,
                FechaNacimiento = interpreteParaEditarDTO.FechaNacimiento == null ? null : Convert.ToDateTime(interpreteParaEditarDTO.FechaNacimiento),
                Pais = interpreteParaEditarDTO.Pais,
                ImagenUrl = interpreteParaEditarDTO.ImagenUrl,
                GeneroID = (int)interpreteParaEditarDTO.GeneroID
            };

            _interpreteRepositorio.ActualizarInterprete(interprete);

        }
        public void EliminarInterprete(int id)
        {
            _interpreteRepositorio.EliminarInterprete(id);
        }

    }
}
