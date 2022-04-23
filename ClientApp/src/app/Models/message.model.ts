import { ChatUserModel } from "./chat-user.model";
import { MessageReplyModel } from "./mesage-reply.model";

export class MessageModel{
  messageId:number;
  body:string;
  activeStatusId:number;
  createdDate :string;
  updatedDate: string;
  user:ChatUserModel;
  messageReplys:MessageReplyModel[];
}
