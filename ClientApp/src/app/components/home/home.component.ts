
import { FormControl } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { ActiceStatusTypeEnum } from 'src/app/models/common.enum';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  private chatServie: ChatService;
  private _hubConnection: HubConnection;

  constructor() { }

  ngOnInit(): void {
    // this.connect();
  }

  public onSendButtonClick(): void {
    this._hubConnection.send('SendMessage', 'test message').then(r => { });
  }

  private connect(): void {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('http://localhost:52864/chathub')
      .build();

    this._hubConnection.on('MessageReceived', (message) => {
      console.log(message);
    });

    this._hubConnection.start()
      .then(() => console.log('connection started'))
      .catch((err) => console.log('error while establishing signalr connection: ' + err));
  }

  GetMessages(){
    this.chatServie.GetAllMessage()
  }
}
