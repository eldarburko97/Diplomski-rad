using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDentalClinicWebAPI.Services
{
    public class CommentService : CRUDService<eDentalClinic.Model.Comment, CommentSearchRequest, Database.Comment, CommentInsertRequest, CommentInsertRequest>
    {
        private eDentalClinicContext _context;
        private IMapper _mapper;
        public CommentService(eDentalClinicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<eDentalClinic.Model.Comment> GetAll(CommentSearchRequest searchRequest)
        {
            var query = _context.Comments.Include(i => i.Topic).AsQueryable();

            if (searchRequest.TopicID != null && searchRequest.TopicID != 0)
            {
                query = query.Where(w => w.TopicID == searchRequest.TopicID);
            }
         
            var list = query.ToList();
            return _mapper.Map<List<eDentalClinic.Model.Comment>>(query);
        }
    }
}
