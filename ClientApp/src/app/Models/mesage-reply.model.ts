import { ChatUserModel } from "./chat-user.model";

export class MessageReplyModel{
  messageReplyId:number;
  messageId:number;
  body:string;
  createdDate :string;
  User:ChatUserModel;
  activeStatusId:number;
}
