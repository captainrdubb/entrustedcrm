import { Directive, ElementRef, Input } from '@angular/core';
import Quill from 'quill';

@Directive({
  selector: '[appQuill]'
})
export class QuillDirective {

  private quill: any;

  public get text(): string {
    return this.quill.getText(0);
  }

  @Input('appQuill')
  public set text(v: string) {
    this.quill.setText(v, 'api');
  }

  constructor(private el: ElementRef) {
    this.quill = new Quill(el.nativeElement, { theme: 'snow' });
  }
}
