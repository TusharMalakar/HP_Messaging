import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';


@Component({
  selector: 'message-box',
  templateUrl: './message-box.component.html'
  // ,
  // styleUrls: ['./message-box.component.scss']
})
export class MessageBoxComponent implements OnInit {
  ngOnInit() {
    console.log('message-box component initiated' );
  }

}
