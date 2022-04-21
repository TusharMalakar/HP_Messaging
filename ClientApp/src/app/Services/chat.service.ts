import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { MessageModel } from "../Models/message.model";

@Injectable({
  providedIn: 'root'
})

export class ChatService{

  private http : HttpClient;
  private baseUrl : string;

  public ChatService(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string){
    this.http=_http;
    this.baseUrl = _baseUrl
  }

  GetAllMessage(){
    return this.http.get<MessageModel[]>(this.baseUrl + 'chat');
  }

  SendMessage(message: MessageModel){
    return this.http.post(this.baseUrl + 'chat', message);
  }

}
