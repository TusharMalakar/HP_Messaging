
import { FormControl, FormGroup } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { ActiceStatusTypeEnum } from 'src/app/models/common.enum';
import * as signalR from '@microsoft/signalr';
import { MessageModel } from 'src/app/models/message.model';


@Component({
  selector: 'app-home',
  templateUrl: './message.component.html',
})
export class MessageComponent implements OnInit {

  message: string;
  private baseUrl: string;
  private chatServie: ChatService;
  private messageList: MessageModel[];


  constructor(@Inject('BASE_URL') _baseUrl: string, private _chatService: ChatService, private cdRef :ChangeDetectorRef) {
    this.baseUrl=_baseUrl;
    this.chatServie = _chatService;
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
          }
          break;
        case 'MessageReply':
          // if(!this.messageReplyList.map(msg => msg.messageReplyId).includes(object.messageReplyId)){
          //   this.messageReplyList.push(object);
          //   this.cdRef.detectChanges();
          // }
          break;
      }
    });
    this.GetMessages();
  }

  SendMessage() {
    console.log(this.message)
    var messageModel = new MessageModel()
    messageModel.body = this.message;
    messageModel.activeStatusId = 1;
    messageModel.createdDate = new Date().toString();

    // this.chatServie.SendMessage(messageModel).subscribe((msg:MessageModel) => {
    //   if(!msg) return;
    //   if(!this.messageList.map(msg => msg.messageId).includes(msg.messageId)){
    //     this.messageList.push(msg);
    //     this.cdRef.detectChanges();
    //   }
    // });
  }

  SendReply(){

  }

  GetMessages(){
    this.chatServie.GetAllMessage().subscribe((msgList:MessageModel[]) => {
      this.messageList=msgList;
    })
  }
}
