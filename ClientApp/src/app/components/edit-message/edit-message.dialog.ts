import { ChangeDetectorRef, Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ActiveStatusTypeEnum } from 'src/app/models/common.enum';
import { MessageModel } from 'src/app/models/message.model';

@Component({
  selector: 'edit-message-dialog',
  templateUrl: './edit-message.dialog.html'
})
export class EditMessageDialog implements OnInit {
  messageForm:FormGroup;
  constructor(@Inject(MAT_DIALOG_DATA) public data: {messageModel: MessageModel}, public dialogRef: MatDialogRef<EditMessageDialog>) {}

  ngOnInit() {
    var msgModel = this.data ? this.data.messageModel : null;
    this.messageForm = new FormGroup({
      messageId: new FormControl(msgModel ? msgModel.messageId : 0),
      body: new FormControl(msgModel ? msgModel.body : ''),
      activeStatusId: new FormControl(msgModel ? msgModel.activeStatusId : 0),
      createdDate: new FormControl(msgModel ? msgModel.createdDate : ''),
      updatedDate: new FormControl(msgModel ? msgModel.updatedDate : ''),
      user: new FormControl(msgModel ? msgModel.user : null),
      messageReplys: new FormControl(msgModel ? msgModel.messageReplys : []),
    });

  }

  updateMessage(){
    var updatedMsg = this.messageForm.value as MessageModel;
    updatedMsg.activeStatusId = ActiveStatusTypeEnum.Edited;
    updatedMsg.updatedDate = new Date().toString();
    this.dialogRef.close({event:'Updated',data: updatedMsg});
  }

  closeDialog() {
    this.dialogRef.close({event:'Cancel'});
  }

}


