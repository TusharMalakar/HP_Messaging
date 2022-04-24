
import { FormControl, FormGroup } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { AfterContentChecked, AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, Inject, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { ActiveStatusTypeEnum } from 'src/app/models/common.enum';
import * as signalR from '@microsoft/signalr';
import { MessageModel } from 'src/app/models/message.model';
import { MessageReplyModel } from 'src/app/models/mesage-reply.model';


@Component({
  selector: 'message-home',
  templateUrl: './message.component.html',
})
export class MessageComponent implements OnInit, OnChanges, AfterViewInit, AfterViewChecked, AfterContentChecked, OnDestroy{

  message: string;
  baseUrl: string;
  chatServie: ChatService;
  messageList: MessageModel[];
  replyToMessage: MessageModel;
  isReplying:boolean = false;

  msgListSubs: any;
  sendMsgSubs: any;
  sendMsgReplySubs: any;


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
  ngAfterViewChecked(){
    window.scrollTo(0, document.body.scrollHeight);
  }
  ngAfterContentChecked(){
    window.scrollTo(0, document.body.scrollHeight);
  }
  ngOnDestroy() {
    //destroy all subscriptions
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

  GetMessages(){
    this.msgListSubs = this.chatServie.GetAllMessage().subscribe((msgList:MessageModel[]) => {
      this.messageList=msgList;
    })
  }

  SendMessage() {
    var messageModel = new MessageModel()
    messageModel.body = this.message;
    messageModel.createdDate = new Date().toString();
    messageModel.activeStatusId = ActiveStatusTypeEnum.Active;
    this.sendMsgSubs = this.chatServie.SendMessage(messageModel).subscribe();
    this.message="";
  }

  EnableReply(msg:MessageModel){
    this.replyToMessage = msg;
    this.isReplying = true;
    this.cdRef.detectChanges();
  }

  CancelRely(){
    this.isReplying=false;
    this.replyToMessage=null;
    this.cdRef.detectChanges();
  }

  SendReply(){
    var replyModel = new MessageReplyModel();
    replyModel.messageId = this.replyToMessage.messageId;
    replyModel.body = this.message;
    replyModel.activeStatusId = ActiveStatusTypeEnum.Active;
    replyModel.createdDate = new Date().toString();
    this.sendMsgReplySubs = this.chatServie.ReplyMessage(replyModel).subscribe();

    this.isReplying=false;
    this.message="";
    this.replyToMessage=null;
    this.cdRef.detectChanges();
  }

  DeleteMessage(_msg:MessageModel){
    var megRef = this.messageList.find(msg => msg.messageId != _msg.messageId);
    megRef.activeStatusId = ActiveStatusTypeEnum.Removed;
    _msg.activeStatusId = ActiveStatusTypeEnum.Removed;
    this.chatServie.SendMessage(_msg).subscribe();
    this.cdRef.detectChanges();
  }

  UpdateMessage(){

  }


}
