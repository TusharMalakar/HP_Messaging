import { ChangeDetectorRef, Component, Inject, Input, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message.model';


@Component({
  selector: 'edit-message-dialog',
  templateUrl: './edit-message.dialog.html'
})
export class EditMessageDialog implements OnInit {

  @Input() message: MessageModel;

  constructor(){
  }

  ngOnInit() {
    console.log('edit-message dialog initiated', this.message );
  }


}


