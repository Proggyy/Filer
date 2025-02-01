import { Component, contentChild, ElementRef, Input, QueryList, viewChild, ViewChild } from '@angular/core';

@Component({
  selector: 'main-post',
  templateUrl: './post.component.html',
  styleUrl: './post.component.css'
})
export class PostComponent {
  isExpanded:boolean = false;
  @Input() tag:string = "";
  expand(){
    this.isExpanded = true;
  }
}
