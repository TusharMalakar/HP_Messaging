import { ChatUserModel } from "./chat-user.model";

export class MessageReplyModel{
  messageReplyId:number;
  messageId:number;
  body:string;
  activeStatusId:number;
  createdDate :string;
  updatedDate :string;
  User:ChatUserModel;
}
