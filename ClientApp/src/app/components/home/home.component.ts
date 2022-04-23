
import { FormGroup } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { Component, Inject, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { ActiceStatusTypeEnum } from 'src/app/models/common.enum';
import * as signalR from '@microsoft/signalr';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  private baseUrl: string;
  private chatServie: ChatService;

  constructor(@Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl=_baseUrl;
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
    });
  }

  SendMessage() {

  }

  SendReply(){

  }

  GetMessages(){
    this.chatServie.GetAllMessage()
  }
}
