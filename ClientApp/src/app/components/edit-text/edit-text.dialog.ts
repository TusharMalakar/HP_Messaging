import { ChangeDetectorRef, Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ActiveStatusTypeEnum } from 'src/app/models/common.enum';
import { MessageModel } from 'src/app/models/message.model';

@Component({
  selector: 'edit-text-dialog',
  templateUrl: './edit-text.dialog.html'
})
export class EditTextDialog implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: {type: string, objectId: Number, text: string}, public dialogRef: MatDialogRef<EditTextDialog>) {}
  textForm: FormGroup;
  ngOnInit() {
    this.textForm = new FormGroup({
      text : new FormControl(this.data ? this.data.text : '')
    })
  }

  updateMessage(){
    this.dialogRef.close({event:'Updated',data: this.textForm.get('text').value});
  }

  closeDialog() {
    this.dialogRef.close({event:'Cancel'});
  }

}


