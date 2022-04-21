import { ChatUserModel } from "./chat-user.model";
import { MessageTypeModel } from "./mesage-type.model";

export class MessageModel{
  messageId:number;
  body:string;
  messageTypeId:number;
  createdBy:number;
  createdDate :string;
  messageType:MessageTypeModel;
  author:ChatUserModel;
}
