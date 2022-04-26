
import { FormControl, FormGroup } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { AfterViewInit, ChangeDetectorRef, Component, Inject, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { ActiveStatusTypeEnum } from 'src/app/models/common.enum';
import * as signalR from '@microsoft/signalr';
import { MessageModel } from 'src/app/models/message.model';
import { MessageReplyModel } from 'src/app/models/mesage-reply.model';
import { MatDialog } from '@angular/material';
import { EditTextDialog } from '../edit-text/edit-text.dialog';

@Component({
  selector: 'message-home',
  templateUrl: './message.component.html',
})
export class MessageComponent implements OnInit, OnChanges, AfterViewInit, OnDestroy{

  message: string;
  baseUrl: string;
  chatServie: ChatService;
  messageList: MessageModel[];
  replyToMessage: MessageModel;
  isReplying:boolean = false;
  isEditing:boolean=false;
  public isCollapsed = false;

  msgListSubs: any;
  sendMsgSubs: any;
  sendMsgReplySubs: any;


  constructor(
    @Inject('BASE_URL') _baseUrl: string
    ,private _chatService: ChatService
    ,private cdRef :ChangeDetectorRef
    ,public dialog: MatDialog
    ) {
    this.baseUrl=_baseUrl;
    this.chatServie = _chatService;
  }

  ngOnChanges() {
    window.scrollTo(0, document.body.scrollHeight);
  }
  ngAfterViewInit(){
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

    connection.on("BroadcastMessage", (eventType, object) => {
      console.log("message broadcast received", eventType, object);
      switch(eventType){
        case 'MessageAdded':
          if(!this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            this.messageList.push(object);
            this.cdRef.detectChanges();
            window.scrollTo(0, document.body.scrollHeight);
          }
          break;
        case 'MessageUpdated' || 'MessageRemoved':
          if(this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            this.messageList = this.messageList.filter(msg => msg.messageId != object.messageId);
            this.messageList.push(object);
            this.messageList = this.messageList.sort((a,b) => a.messageId-b.messageId);
            this.cdRef.detectChanges();
          }
          break;
        case 'MessageReplyAdded':
          if(this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            var msgRef = this.messageList.find(msg => msg.messageId=object.messageId);
            msgRef.messageReplys.push(object);
            this.messageList = this.messageList.filter(msg => msg.messageId != msgRef.messageId);
            this.messageList.push(msgRef);
            this.messageList = this.messageList.sort((a,b) => a.messageId-b.messageId);
            this.cdRef.detectChanges();
          }
          break;
        case 'MessageReplyUpdated' || 'MessageReplyRemoved':
          if(this.messageList.map(msg => msg.messageId).includes(object.messageId)){
            var msgRef = this.messageList.find(msg => msg.messageId=object.messageId);
            msgRef.messageReplys.push(object);
            this.messageList = this.messageList.filter(msg => msg.messageId != msgRef.messageId);
            this.messageList.push(msgRef);
            this.messageList = this.messageList.sort((a,b) => a.messageId-b.messageId);
            this.cdRef.detectChanges();
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

  SaveMessage() {
    var messageModel = new MessageModel()
    messageModel.body = this.message;
    messageModel.createdDate = this.GetFormatedDate();
    messageModel.activeStatusId = ActiveStatusTypeEnum.Active;
    this.sendMsgSubs = this.chatServie.SaveMessage(messageModel).subscribe();
    this.message="";
  }

  EnableReply(msg:MessageModel){
    this.replyToMessage = msg;
    this.isReplying = true;
    this.cdRef.detectChanges();
  }

  CancelReply(){
    this.isReplying=false;
    this.replyToMessage=null;
    this.cdRef.detectChanges();
  }

  SaveReply(){
    var replyModel = new MessageReplyModel();
    replyModel.messageId = this.replyToMessage.messageId;
    replyModel.body = this.message;
    replyModel.activeStatusId = ActiveStatusTypeEnum.Active;
    replyModel.createdDate = this.GetFormatedDate();
    this.sendMsgReplySubs = this.chatServie.SaveReply(replyModel).subscribe();

    this.isReplying=false;
    this.message="";
    this.replyToMessage=null;
    this.cdRef.detectChanges();
  }

  DeleteMessage(_msg:MessageModel){
    var megRef = this.messageList.find(msg => msg.messageId != _msg.messageId);
    megRef.activeStatusId = ActiveStatusTypeEnum.Removed;
    _msg.activeStatusId = ActiveStatusTypeEnum.Removed;
    this.chatServie.SaveMessage(_msg).subscribe();
    this.cdRef.detectChanges();
  }

  OpenEditTextDialog(model:any, type:string): void {
    const dialogRef = this.dialog.open(EditTextDialog,{data: { text:model.body}});
    dialogRef.afterClosed().subscribe(result => {
      if(result && result.data && result.event=='Updated'){
        model.body = result.data;
        model.activeStatusId = ActiveStatusTypeEnum.Edited;
        model.updatedDate = this.GetFormatedDate();
        if(type=='Message'){
          this.chatServie.SaveMessage(model).subscribe();
        }
        else if(type=='Reply'){
          this.chatServie.SaveReply(model).subscribe();
        }
      }
    });
  }

  DeleteReplyMessage(){

  }

  GetFormatedDate(){
    const date = new Date();
    let options = {hour: "2-digit", minute: "2-digit"};
    return date.toLocaleDateString() + ' ' + date.toLocaleTimeString("en-us", options as Intl.DateTimeFormatOptions);
  }
}
