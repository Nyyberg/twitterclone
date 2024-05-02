using EasyNetQ;
using Messaging.SharedMessages;
using MessagingService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineService.DTOs;

namespace TimelineService.Handlers
{
    public class AddPostToTimelineHandler : BackgroundService
    {
        private IServiceProvider _serviceProvider;

        public AddPostToTimelineHandler(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

        public async void HandlePostToTimeline(AddPostToTimeline message)    
        {
            using var Scope = _serviceProvider.CreateScope();
            var timelineservice = Scope.ServiceProvider.GetRequiredService<ITimelineService>();
            var post = new AddPostToTimelineDTO()
            {
                PostId = message.PostId,
                TimelineId = message.TimelineId
                
            };
            await timelineservice.AddPostToTimeline(post);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var messageClient = new MessagingClient(RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualHost=/;username=guest;password=guest"));
            string topic = "AddPostToTimeline";

            await messageClient.Listen<AddPostToTimeline>(HandlePostToTimeline, topic);
        }
    }
}
