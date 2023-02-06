using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using Microsoft.EntityFrameworkCore;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Epic;
using AutoMapper;

namespace BouvetTask.Services
{
    public class EpicService : IEpicService
    {
        private readonly IMapper _mapper;

        public EpicService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GetEpicDto> GetEpicById(int epicId)
        {
            using var context = new Bouvet_DBContext();
            var epic = await context.Epics
                .Include(epic => epic.Tasks)
                .Where(epic => epic.EpicId == epicId)
                .FirstOrDefaultAsync();

            return _mapper.Map<GetEpicDto>(epic);
        }

        public async Task<List<GetEpicDto>> GetAllEpics()
        {
            using var context = new Bouvet_DBContext();
            var epics = await context.Epics
                .Include(epic => epic.Tasks)
                .Select(epic => _mapper.Map<GetEpicDto>(epic))
                .ToListAsync();

            return epics;
        }

        public async Task<string> AddEpic(AddEpicDto newEpic)
        {
            using var context = new Bouvet_DBContext();
            var mappedNewEpic = _mapper.Map<Epic>(newEpic);
            await context.Epics.AddAsync(mappedNewEpic);
            await context.SaveChangesAsync();

            return "New epic added";
        }

        public async Task<string> UpdateEpic(UpdateEpicDto updatedEpic)
        {
            using var context = new Bouvet_DBContext();
            var epicId = updatedEpic.EpicId;
            Epic epic = await context.Epics
                .Where(e => e.EpicId == epicId)
                .FirstOrDefaultAsync();

            if (epic == null)
            {
                return "There is no epic with id " + epicId;
            }

            var mappedUpdatedEpic = _mapper.Map<Epic>(updatedEpic);
            context.ChangeTracker.Clear();
            context.Epics.Update(mappedUpdatedEpic);
            await context.SaveChangesAsync();

            return "Epic updated";
        }

        public async Task<string> DeleteEpicByID(int epicId)
        {
            using var context = new Bouvet_DBContext();
            Epic epic = await context.Epics
                .Where(e => e.EpicId == epicId)
                .FirstOrDefaultAsync();

            if (epic == null)
            {
                return "There is no epic with id " + epicId;
            }

            context.Epics.Remove(epic);
            await context.SaveChangesAsync();

            return "Epic deleted";
        }
    }
}
