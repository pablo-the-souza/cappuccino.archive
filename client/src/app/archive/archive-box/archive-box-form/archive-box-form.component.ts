import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../../archive.service';
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-archive-box-form',
  templateUrl: './archive-box-form.component.html',
  styleUrls: ['./archive-box-form.component.css']
})
export class ArchiveBoxFormComponent implements OnInit {
  update: string;
  selectedOption: Guid; 
  boxes: Observable<any>; 
  isUpdate: boolean; 
  guid: Guid
  

  constructor(public service: ArchiveService) { 
      this.guid = Guid.create();
      
  }

  ngOnInit(): void {
    this.isUpdate = this.service.isBoxUpdate; 
    this.resetForm();
    this.boxes = this.service.getBoxes();
  }



  onSubmit(form: NgForm) {
    console.log(form.value)
    this.isUpdate = this.service.isBoxUpdate; 
    if (!this.isUpdate)
      {
        console.log("I'm Insert");
        this.insertBox(form)
      }
      
    else 
      this.updateBox(form)
  }

  insertBox(form: NgForm) {
    console.log("I'm boxID = " + form.value.boxId)
    this.service.postBox().subscribe(
      res => {
        this.resetForm(form);
        this.service.getBoxesForList();
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form?: NgForm) {
    console.log(this.guid)
    if (form != null)
      form.resetForm();

    this.service.boxFormData = {
      id: this.guid.toString(),
      name: "",
      code: "",
      destructionFlag: "",
      reference: "",
      dateLeftOffice: "",
      comments: ""
    }
  }


  updateBox(form: NgForm) {
    this.service.putBox().subscribe(
      res => {
        console.log("Update ok")
        this.resetForm(form);
        this.service.getBoxesForList();
      },
      err => {
        console.log(err);
        
      }
    );
  }
}
