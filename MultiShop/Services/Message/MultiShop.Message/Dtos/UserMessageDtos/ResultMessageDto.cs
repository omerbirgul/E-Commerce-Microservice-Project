﻿namespace MultiShop.Message.Dtos.UserMessageDtos
{
    public class ResultMessageDto
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageDate { get; set; }
        public bool IsRead { get; set; }
    }
}