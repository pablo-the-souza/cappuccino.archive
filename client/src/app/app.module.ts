import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ArchiveComponent } from './archive/archive.component';
import { ArchiveFormComponent } from './archive/archive-form/archive-form.component';
import { ArchiveListComponent } from './archive/archive-list/archive-list.component';


@NgModule({
  declarations: [
    AppComponent,
    ArchiveComponent,
    ArchiveFormComponent,
    ArchiveListComponent,
    

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FlexLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
