import { ScriptsService } from './scripts.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ScriptlistComponent } from './scriptlist/scriptlist.component';
import { ScriptdetailComponent } from './scriptdetail/scriptdetail.component';
import { CodemirrorComponent } from './codemirror/codemirror.component';

@NgModule({
  declarations: [
    AppComponent,
    ScriptlistComponent,
    ScriptdetailComponent,
    CodemirrorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [ScriptsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
