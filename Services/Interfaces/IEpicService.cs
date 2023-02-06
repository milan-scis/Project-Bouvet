using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using BouvetTask.Dtos.Epic;

namespace BouvetTask.Services.Interfaces
{
    public interface IEpicService
    {
        Task<GetEpicDto> GetEpicById(int epicId);
        Task<List<GetEpicDto>> GetAllEpics();
        Task<string> AddEpic(AddEpicDto newEpic);
        Task<string> UpdateEpic(UpdateEpicDto updatedEpic);
        Task<string> DeleteEpicByID(int epicId);
    }
}
