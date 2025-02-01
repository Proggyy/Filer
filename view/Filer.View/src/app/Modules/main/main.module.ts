import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainFrameComponent } from './main-frame/main-frame.component';
import { MainFeedComponent } from './main-feed/main-feed.component';
import { BrowserModule } from '@angular/platform-browser';
import { PostComponent } from './post/post.component';



@NgModule({
  declarations: [
    MainFrameComponent,
    MainFeedComponent,
    PostComponent
  ],
  imports: [
    CommonModule
  ],
  providers:[],
  bootstrap: [MainFrameComponent]
})
export class MainModule { }
