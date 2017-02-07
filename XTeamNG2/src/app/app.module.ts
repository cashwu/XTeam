import { ScriptsService } from './scripts.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { CodemirrorModule } from 'ng2-codemirror';

import { AppComponent } from './app.component';
import { ScriptlistComponent } from './scriptlist/scriptlist.component';
import { ScriptdetailComponent } from './scriptdetail/scriptdetail.component';

@NgModule({
  declarations: [
    AppComponent,
    ScriptlistComponent,
    ScriptdetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    CodemirrorModule
  ],
  providers: [ScriptsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
