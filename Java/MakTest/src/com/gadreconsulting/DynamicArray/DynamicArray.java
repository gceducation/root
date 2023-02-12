/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gadreconsulting.DynamicArray;

/**
 *
 * @author gadre
 * @param <T>
 */
public class DynamicArray<T> {
	private T[] _arrT = null;
	private static final int __jSizeInitialDefault = 8;
	private int _jSizeIncr;
	private int _jSizeCurrent = 0;

	public DynamicArray() {
		this(__jSizeInitialDefault);
	}

	public DynamicArray(int jSizeInitial) {
		initialize(jSizeInitial);
	}

	private void initialize(int jSizeInitial) {

		_arrT = allocateArray(jSizeInitial);
		_jSizeIncr = Math.max(1, jSizeInitial / 2);
	}

	public void add(T tObject) {
		ensureSize(_jSizeCurrent + 1);
		_arrT[_jSizeCurrent] = tObject;

		_jSizeCurrent++;
	}

	public T get(int jPosition) {
		return _arrT[jPosition];
	}

	public void set(int jPosition, T tObject) {
		_arrT[jPosition] = tObject;
	}

	public int size() {
		return _jSizeCurrent;
	}

	public int allocatedSize() {
		return _arrT.length;
	}

	public void insertAt(int jPosition) {
		if (jPosition >= 0) {
			ensureSize(jPosition);
			System.arraycopy(_arrT, jPosition, _arrT, jPosition + 1, _arrT.length - jPosition);
		}

	}

	public void removeAt(int jPosition) {
		if ((jPosition >= 0) && (jPosition < _jSizeCurrent)) {
			System.arraycopy(_arrT, jPosition + 1, _arrT, jPosition, _arrT.length - jPosition - 1);
			_jSizeCurrent--;
		}
	}

	public boolean fContains(T tobj) {
		boolean fFound = false;
		for (int j = 0; j < _jSizeCurrent; j++) {
			if (tobj == _arrT[j]) {
				fFound = true;
				break;
			}
		}
		return fFound;
	}

	private void ensureSize(int jNewSizeNeeded) {
		if (jNewSizeNeeded > _arrT.length) {
			// get the next multiple of _jSizeIncr
			int jNewSizeAlloc = (jNewSizeNeeded / _jSizeIncr + 1) * _jSizeIncr;
			if (jNewSizeAlloc > _arrT.length) {
				T[] arrTNew = allocateArray(jNewSizeAlloc);
				System.arraycopy(_arrT, 0, arrTNew, 0, _arrT.length);
				_arrT = arrTNew;
			}
		}
	}

	@SuppressWarnings("unchecked")
	private T[] allocateArray(int jSize) {
		T[] arrT;
		arrT = (T[]) new Object[jSize];
		return arrT;
	}

}
