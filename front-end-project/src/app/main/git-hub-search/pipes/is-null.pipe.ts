import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'isNull'
})
export class IsNullPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return !value ? "n/a" : "";
  }

}
