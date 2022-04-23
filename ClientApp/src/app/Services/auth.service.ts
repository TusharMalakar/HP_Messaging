import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { ChatUserModel } from "../models/chat-user.model";

@Injectable({
  providedIn: 'root'
})

export class AuthService{

  private http : HttpClient;
  private baseUrl : string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string){
    this.http=_http;
    this.baseUrl = _baseUrl
  }

  SignIn(profile: ChatUserModel){
    return this.http.post<ChatUserModel>(this.baseUrl + 'auth',profile);
  }

}
