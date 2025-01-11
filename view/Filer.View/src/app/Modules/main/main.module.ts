import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainFrameComponent } from './main-frame/main-frame.component';
import { MainFeedComponent } from './main-feed/main-feed.component';



@NgModule({
  declarations: [
    MainFrameComponent,
    MainFeedComponent
  ],
  imports: [
    CommonModule
  ],
  providers:[],
  bootstrap: [MainFrameComponent]
})
export class MainModule { }
