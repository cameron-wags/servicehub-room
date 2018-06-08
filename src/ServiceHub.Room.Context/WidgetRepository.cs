using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context
{
    public class WidgetRepository
    {
        private readonly IMongoCollection<Widget> _widgets;

        public WidgetRepository(IMongoClient mongoClient, string databaseName, string widgetTableName)
        {
            IMongoDatabase db = mongoClient.GetDatabase(databaseName);
            _widgets = db.GetCollection<Widget>(widgetTableName);
        }

        public void Insert(Widget widget)
        {
            _widgets.InsertOne(widget);
        }

        public IQueryable<Widget> Get()
        {
            return _widgets.AsQueryable();
        }

        public Widget GetById(Guid id)
        {
            return _widgets.AsQueryable().FirstOrDefault(x => x.WidgetId == id);
        }

        public void Update(Widget widget)
        {
            var filter = Builders<Widget>.Filter.Eq(x => x.WidgetId, widget.WidgetId);
            var updateGender = Builders<Widget>.Update.Set(x => x.WidgetGender, widget.WidgetGender);
            _widgets.UpdateOneAsync(filter, updateGender);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<Widget>.Filter.Eq(x => x.WidgetId, id);
            _widgets.DeleteOne(filter);
        }

        public void DeleteAll()
        {
            var filter = Builders<Widget>.Filter.Where(x => true);
            _widgets.DeleteMany(filter); 
        }
    }
}
