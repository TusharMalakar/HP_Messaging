
import { FormControl, FormGroup } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { AfterContentChecked, AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, Inject, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { ActiceStatusTypeEnum } from 'src/app/models/common.enum';
import * as signalR from '@microsoft/signalr';
import { MessageModel } from 'src/app/models/message.model';


@Component({
  selector: 'message-home',
  templateUrl: './message.component.html',
})
export class MessageComponent implements OnInit, OnChanges, AfterViewInit{

  message: string;
  baseUrl: string;
  chatServie: ChatService;
  messageList: MessageModel[];


  constructor(@Inject('BASE_URL') _baseUrl: string, private _chatService: ChatService, private cdRef :ChangeDetectorRef) {
    this.baseUrl=_baseUrl;
    this.chatServie = _chatService;
  }
  ngOnChanges() {
    window.scrollTo(0, document.body.scrollHeight);
  }
  ngAfterViewInit(){
    window.scrollTo(0, document.body.scrollHeight);
  }

  ngOnInit(): void {
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(this.baseUrl+'chathub')
      .build();

    connection.start().then(function () {
      console.log('SignalR Connected!');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    connection.on("BroadcastMessage", (type, object) => {
      console.log("message broadcast received", type, object);
      switch(type){
        case 'Message':
          if(!this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            this.messageList.push(object);
            this.cdRef.detectChanges();
            window.scrollTo(0, document.body.scrollHeight);
          }
          break;
        case 'MessageReply':
          if(this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            var msgRef = this.messageList.find(msg => msg.messageId=object.messageId);
            msgRef.messageReplys.push(object);
            this.messageList = this.messageList.filter(msg => msg.messageId != msgRef.messageId);
            this.messageList.push(msgRef);
            this.cdRef.detectChanges();
            window.scrollTo(0, document.body.scrollHeight);
          }
          break;
      }
    });
    this.GetMessages();
  }

  SendMessage() {
    var messageModel = new MessageModel()
    messageModel.body = this.message;
    this.message="";
    messageModel.activeStatusId = ActiceStatusTypeEnum.Active;
    messageModel.createdDate = new Date().toString();
    this.chatServie.SendMessage(messageModel).subscribe();
  }

  SendReply(){

  }

  GetMessages(){
    this.chatServie.GetAllMessage().subscribe((msgList:MessageModel[]) => {
      this.messageList=msgList;
    })
  }
}
