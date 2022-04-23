import { ChatUserModel } from "./chat-user.model";
import { MessageReplyModel } from "./mesage-reply.model";

export class MessageModel{
  messageId:number;
  body:string;
  createdDate :string;
  user:ChatUserModel;
  messageReplys:MessageReplyModel[];
  author:ChatUserModel;
  activeStatusId:number;
}
