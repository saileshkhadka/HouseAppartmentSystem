using HouseApartment.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartments.Services
{
    public class NoticeServices : INoticeServices
    {
        protected DataContext db;
        public NoticeServices()
        {
            db = new DataContext();
        }
        public List<NoticeViewModel> ListNotice()
        {
            //todo:add server side pagination
            var query = db.Notice.Select(x => new NoticeViewModel()
            {
                Id = x.ID,
                Name = x.Name,
                Description = x.Description,
                FromDate = x.FromDate.ToShortDateString(),
                ToDate = x.ToDate.ToShortDateString(),

            }).ToList();
            return query;
            //return queryable.ToDataSourceResult<Notice, NoticeViewModel>(request.Model, new Sort() { Field = "Name", Dir = "asc" });
        }
        public void AddNotice(NoticeViewModel model)
        {

            model.Id = Guid.NewGuid();
            var data = new Notice()
            {
                ID = model.Id,
                Name = model.Name,
                Description = model.Description,
                FromDate = Convert.ToDateTime(model.FromDate),
                ToDate = Convert.ToDateTime(model.ToDate),

            };
            db.Notice.Add(data);
            db.SaveChanges();
        }
        public void UpdateNotice(NoticeViewModel model)
        {

            var data = GetNotice(model.Id);
            if (data != null)
            {

                data.Name = model.Name;
                data.Description = model.Description;
                data.FromDate = model.FromDate;
                data.ToDate = model.ToDate;

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            //var deletedEntities = existingLists.Where(p => serviceRequestModel.Model.NoticeAttachments.All(p2 => p2.Id != p.Id));
            //deletedEntities.ToList().ForEach(c =>
            //{
            //    c.AttachmentUrl.DeleteFile();
            //});

            //var mapped = _mapper.Map(serviceRequestModel.Model, data);

            //mapped.NoticeAttachments.Clear();
            //serviceRequestModel.Model.NoticeAttachments.ForEach(model =>
            //{
            //    var existingEntity = existingLists.SingleOrDefault(e => e.Id == model.Id);
            //    data.NoticeAttachments.Add(existingEntity == null
            //        ? _mapper.Map<NoticeAttachmentViewModel, NoticeAttachment>(model)
            //        : _mapper.Map(model, existingEntity));
            //});

            //repo.Update(mapped);
            //_genericUnitOfWork.SaveChanges();
        }
        //private List<NoticeAttachmentViewModel> MoveNoticeAttachment(List<NoticeAttachmentViewModel> lists)
        //{
        //    var tempPath = System.Configuration.ConfigurationManager.AppSettings["TempFolder"].Replace("~", "");
        //    lists.Where(c => c.AttachmentUrl.Contains(tempPath)).ToList().ForEach(c =>
        //    {
        //        c.AttachmentUrl = c.AttachmentUrl.MoveToDestination("Notice");
        //    });
        //    return lists;
        //}
        public NoticeViewModel GetNotice(Guid id)
        {
            var query = db.Notice.Where(x => x.ID == id).FirstOrDefault();

            var result = new NoticeViewModel()
            {
                //Id = getData.ID,
                Name = query.Name,
                Description = query.Description,

                FromDate = query.ToDate.ToShortDateString(),
                ToDate = query.ToDate.ToShortDateString()
            };
            return result;
        }
        public void DeleteNotice(Guid id)
        {
            var IsExistData = db.Notice.Where(x => x.ID == id).FirstOrDefault();
            db.Notice.Remove(IsExistData);
            db.SaveChanges();
        }
        //private List<NoticeAttachmentViewModel> MoveNoticeAttachment(List<NoticeAttachmentViewModel> lists)
        //{
        //    var tempPath = System.Configuration.ConfigurationManager.AppSettings["TempFolder"].Replace("~", "");
        //    lists.Where(c => c.AttachmentUrl.Contains(tempPath)).ToList().ForEach(c =>
        //    {
        //        c.AttachmentUrl = c.AttachmentUrl.MoveToDestination("Notice");
        //    });
        //    return lists;
        //}

    }
}
