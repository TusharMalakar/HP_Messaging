import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { MessageReplyModel } from "../models/mesage-reply.model";
import { MessageModel } from "../models/message.model";

@Injectable({
  providedIn: 'root'
})

export class ChatService {

  private http : HttpClient;
  private baseUrl : string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string){
    this.http=_http;
    this.baseUrl = _baseUrl
  }

  GetAllMessage(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('authHash')}`
    })
    return this.http.get<MessageModel[]>(this.baseUrl + 'chat/GetMessages', { headers: headers });
  }

  SendMessage(message: MessageModel){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('authHash')}`
    })
    return this.http.post(this.baseUrl + 'chat/SendMsg', message, { headers: headers });
  }

  ReplyMessage(replyModel: MessageReplyModel){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('authHash')}`
    })
    return this.http.post(this.baseUrl + 'chat/ReplyMsg', replyModel, { headers: headers });
  }

}
